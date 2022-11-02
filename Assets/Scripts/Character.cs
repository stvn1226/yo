using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character :MonoBehaviour {
	public int hp;
	[SerializeField]
	protected float speed;
	public abstract Vector2 move ();
}


