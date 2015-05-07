using UnityEngine;

public abstract class VisualEffect : MonoBehaviour {
	[SerializeField] private GameObject explosionPrefab;

	protected virtual void Start() {
		SpawnParticles();
		Debug.Log("BaseExplosion Start()");
	}

	private void SpawnParticles() {
		NGUITools.AddChild(gameObject, explosionPrefab);
	}
}