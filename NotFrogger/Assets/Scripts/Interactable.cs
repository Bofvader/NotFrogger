﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	enum eActionType { GOAL, HAZARD, SAFEZONE }

	public delegate void CollisionAction();
	public static CollisionAction OnCollision;

	public delegate void CollisionToggle(bool toggle);
	public static CollisionToggle CollisionBlocker;

	[SerializeField] eActionType m_type;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if(OnCollision != null)
			{
				HandleAction(collision.gameObject, true);
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (OnCollision != null)
			{
				HandleAction(collision.gameObject, true);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (OnCollision != null)
			{
				HandleAction(other.gameObject, true);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (OnCollision != null)
			{
				HandleAction(collision.gameObject, true);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (OnCollision != null)
			{
				HandleAction(other.gameObject, false);
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (OnCollision != null)
			{
				HandleAction(collision.gameObject, false);
			}
		}
	}

	void HandleAction(GameObject go, bool isEnter)
	{
		switch(m_type)
		{
			case eActionType.SAFEZONE:
				CollisionBlocker(isEnter);
				break;
			case eActionType.GOAL:
				OnCollision();
				GoalReaction();
				break;
			case eActionType.HAZARD:
				OnCollision();
				break;
		}
	}

	void GoalReaction()
	{
		Debug.Log("GOOOOOOALLL!!!!!!!");
	}
}
