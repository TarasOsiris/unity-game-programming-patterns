using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                {
                    Debug.Log("No instance of " + typeof(T) + ", a temporary one is created.");
                    _instance = new GameObject("Temp Instance of " + typeof(T), typeof(T)).GetComponent<T>();
                }

                _instance.Init();
            }

            return _instance;
        }
    }

    // If no other monobehaviour request the instance in an awake function
    // executing before this one, no need to search the object.
    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this as T;
            _instance.Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // This function is called when the instance is used the first time
    // Put all the initializations you need here, as you would do in Awake
    public virtual void Init() { }
}