using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SimplePrefabPool
{
	public abstract class AbstractPrefabPool<T> : IPrefabPool<T> where T : Object
	{
	    private readonly List<T> _availableInstances;
	    private readonly T _objectToCopy;
	
	    private readonly int _growth;
	
	    public int UnrecycledPrefabCount { get; private set; }
	
	    public int AvailablePrefabCount
	    {
	        get { return _availableInstances.Count; }
	    }
	
	    public int AvailablePrefabCountMaximum { get; private set; }

        #region constructors

	    protected AbstractPrefabPool(T objectToCopy, GameObject parent)
	        : this(objectToCopy, parent, 0)
	    {
	    }

	    protected AbstractPrefabPool(T objectToCopy, GameObject parent, int initialSize)
	        : this(objectToCopy, parent, initialSize, 1)
	    {
	    }

	    protected AbstractPrefabPool(T objectToCopy, GameObject parent, int initialSize, int growth)
	        : this(objectToCopy, parent, initialSize, growth, int.MaxValue)
	    {
	    }

	    protected AbstractPrefabPool(T objectToCopy, GameObject parent, int initialSize, int growth, int availableItemsMaximum)
	    {
	        if (growth <= 0)
	        {
	            throw new ArgumentOutOfRangeException("growth must be greater than 0!");
	        }
	        if (availableItemsMaximum < 0)
	        {
	            throw new ArgumentOutOfRangeException("availableItemsMaximum must be at least 0!");
	        }
	
	        _objectToCopy = objectToCopy;
	        _growth = growth;
	        AvailablePrefabCountMaximum = availableItemsMaximum;
	        _availableInstances = new List<T>(initialSize);
	
	        if (initialSize > 0)
	        {
	            BatchAllocatePoolItems(initialSize);
	        }
	    }
        #endregion

        #region abstract_members
        /*
	     * Every item passes this method before it gets recycled
	     */
        protected abstract void OnHandleAllocatePrefab(T prefabInstance);

        /*
         * Every item passes this method before it is obtained from the pool
         */
        protected abstract void OnHandleObtainPrefab(T prefabInstance);

	    /*
	     * Every item passes this method before it gets recycled
	     */
	    protected abstract void OnHandleRecyclePrefab(T prefabInstance);

	    #endregion

	    public T ObtainPrefabInstance()
	    {
            T prefabInstance;

            if (_availableInstances.Count > 0)
            {
                prefabInstance = RetrieveLastItemAndRemoveIt();
            }
            else
            {
                if (_growth == 1 || AvailablePrefabCountMaximum == 0)
                {
                    prefabInstance = AllocatePoolItem();
                }
                else
                {
                    BatchAllocatePoolItems(_growth);
                    prefabInstance = RetrieveLastItemAndRemoveIt();
                }

                Debug.Log(GetType().FullName + "<" + prefabInstance.GetType().Name + "> was exhausted, with " + UnrecycledPrefabCount +
                " items not yet recycled.  " +
                "Allocated " + _growth + " more.");
            }

            OnHandleObtainPrefab(prefabInstance);
            UnrecycledPrefabCount++;

            return prefabInstance;
	    }




	    public void RecyclePrefabInstance(T prefab)
	    {
	        if (prefab == null) { throw new ArgumentNullException("Cannot recycle null item!"); }
	
	        OnHandleRecyclePrefab(prefab);

	        if (_availableInstances.Count < AvailablePrefabCountMaximum) { _availableInstances.Add(prefab); }
	        UnrecycledPrefabCount--;
	
	        if (UnrecycledPrefabCount < 0) { Debug.Log("More items recycled than obtained"); }
	    }

	    private T AllocatePoolItem()
	    {
	        var instance = Object.Instantiate(_objectToCopy, Vector3.zero, Quaternion.identity) as T;
            OnHandleAllocatePrefab(instance);
	        return instance;
	    }

	    #region herlper_methods
	    private void BatchAllocatePoolItems(int count)
	    {
	        List<T> availableItems = _availableInstances;
	
	        int allocationCount = AvailablePrefabCountMaximum - availableItems.Count;
	        if (count < allocationCount)
	        {
	            allocationCount = count;
	        }
	
	        for (int i = allocationCount - 1; i >= 0; i--)
	        {
	            availableItems.Add(AllocatePoolItem());
	        }
	    }

	    private T RetrieveLastItemAndRemoveIt()
	    {
	        int lastElementIndex = _availableInstances.Count - 1;
	        var prefab = _availableInstances[lastElementIndex];
	        _availableInstances.RemoveAt(lastElementIndex);
	
	        return prefab;
        }
        #endregion
    }
}