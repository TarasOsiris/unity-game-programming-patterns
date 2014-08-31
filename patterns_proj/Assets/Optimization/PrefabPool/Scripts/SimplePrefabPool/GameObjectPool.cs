using UnityEngine;

namespace SimplePrefabPool
{
    public class GameObjectPool : AbstractPrefabPool<GameObject>
    {
        public GameObjectPool(GameObject objectToCopy, GameObject parent) : base(objectToCopy, parent)
        {
        }

        public GameObjectPool(GameObject objectToCopy, GameObject parent, int initialSize) : base(objectToCopy, parent, initialSize)
        {
        }

        public GameObjectPool(GameObject objectToCopy, GameObject parent, int initialSize, int growth) : base(objectToCopy, parent, initialSize, growth)
        {
        }

        public GameObjectPool(GameObject objectToCopy, GameObject parent, int initialSize, int growth, int availableItemsMaximum) : base(objectToCopy, parent, initialSize, growth, availableItemsMaximum)
        {
        }

        #region abstract_members_implementation

        protected override void OnHandleAllocatePrefab(GameObject prefabInstance)
        {
            prefabInstance.SetActive(false);
        }

        protected override void OnHandleObtainPrefab(GameObject prefabInstance)
        {
            prefabInstance.SetActive(true);
        }

        protected override void OnHandleRecyclePrefab(GameObject prefabInstance)
        {
            prefabInstance.SetActive(false);
        }

        #endregion
    }
}
