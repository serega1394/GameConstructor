using UnityEngine;
using System.Collections;

public interface CollisionListener {

	void distributeCollisionOnLevel(GameObject source, GameObject collision);
}
