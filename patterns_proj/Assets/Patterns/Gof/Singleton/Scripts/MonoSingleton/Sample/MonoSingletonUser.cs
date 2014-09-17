using UnityEngine;

public class MonoSingletonUser : MonoBehaviour
{
    public UILabel valueIndicatorLabel;

    void OnClick()
    {
        MySingletonGameManager.Instance.DoSomeSingletonStuff();
    }

    void Update()
    {
        valueIndicatorLabel.text = "Current value: " + MySingletonGameManager.Instance.SomeValue;
    }
}
