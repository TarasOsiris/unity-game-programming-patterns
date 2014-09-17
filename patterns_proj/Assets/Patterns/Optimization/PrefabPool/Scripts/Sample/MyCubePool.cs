using SimplePrefabPool;
using UnityEngine;

public class MyCubePool : AbstractPrefabPool<MyCube>
{
    public MyCubePool(MyCube objectToCopy, GameObject parent) : base(objectToCopy, parent)
    {
    }

    public MyCubePool(MyCube objectToCopy, GameObject parent, int initialSize) : base(objectToCopy, parent, initialSize)
    {
    }

    public MyCubePool(MyCube objectToCopy, GameObject parent, int initialSize, int growth) : base(objectToCopy, parent, initialSize, growth)
    {
    }

    public MyCubePool(MyCube objectToCopy, GameObject parent, int initialSize, int growth, int availableItemsMaximum) : base(objectToCopy, parent, initialSize, growth, availableItemsMaximum)
    {
    }

    /*
     * Cube gets YELLOW when allocated
     */
    protected override void OnHandleAllocatePrefab(MyCube prefabInstance)
    {
        prefabInstance.gameObject.SetActive(true);
        prefabInstance.renderer.material.color = Color.yellow;
        prefabInstance.transform.position = new Vector3(-3, -3, -3);
    }

    /*
     * Cube gets GREEN when obtained
     */
    protected override void OnHandleObtainPrefab(MyCube prefabInstance)
    {
        prefabInstance.gameObject.SetActive(true);
        prefabInstance.renderer.material.color = Color.green;
    }

    /*
     * Cube gets RED when recycled
     * 
     * Intentionally left active to stay visible
     */
    protected override void OnHandleRecyclePrefab(MyCube prefabInstance)
    {
        prefabInstance.gameObject.SetActive(true);
        prefabInstance.renderer.material.color = Color.red;
    }
}