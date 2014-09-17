using UnityEngine;

namespace SimplePrefabPool
{
	public interface IPrefabPool<T> where T : Object
	{
	    int UnrecycledPrefabCount { get; }
	
	    int AvailablePrefabCount { get; }
	
	    int AvailablePrefabCountMaximum { get; }
	
	    T ObtainPrefabInstance();
	
	    void RecyclePrefabInstance(T prefab);
	}
}