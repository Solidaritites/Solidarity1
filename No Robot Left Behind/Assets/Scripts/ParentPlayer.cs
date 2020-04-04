using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayer : MonoBehaviour
{
    public GameObject characterOne { get; set; }
    public GameObject characterTwo { get; set; }
    public GameObject characterThree { get; set; }

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.Player != null)
        {
            characterOne = GameManager.Instance.Player.transform.Find("Character1").gameObject;
            Debug.Log("Character One Has Been Assigned");
            characterTwo = GameManager.Instance.Player.transform.Find("Character2").gameObject;
            Debug.Log("Character Two Has Been Assigned");
            characterThree = GameManager.Instance.Player.transform.Find("Character3").gameObject;
            Debug.Log("Character Three Has Been Assigned");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Has Been Entered");

        if(other.gameObject == characterOne)
        {
            characterOne.transform.parent = transform;
        }

        if(other.gameObject == characterTwo)
        {
            characterTwo.transform.parent = transform;
        }

        if(other.gameObject == characterThree)
        {
            characterThree.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Has Been Exit");

        if(other.gameObject == characterOne)
        {
            characterOne.transform.parent = null;
        }

        if(other.gameObject == characterTwo)
        {
            characterTwo.transform.parent = null;
        }

        if(other.gameObject == characterThree)
        {
            characterThree.transform.parent = null;
        }
    }
}
