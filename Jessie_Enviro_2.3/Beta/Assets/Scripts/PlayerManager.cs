using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public iTweenPath path;
	
	static PlayerManager inst;
	
	void Awake() {
		inst = this;
	}
	
	public static float GetPathLength() {
		return iTween.PathLength( iTweenPath.GetPath(inst.path.pathName) );
	}
	public static Vector3[] GetCurrentPath() {
		return iTweenPath.GetPath(inst.path.pathName);
	}
}
