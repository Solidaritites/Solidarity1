using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public int AllowedCharacterIdx = -1;

    private void Update()
    {
        foreach (CharacterController character in GameManager.Instance.Player.Characters)
        {
            Vector3 dir = character.transform.position - transform.position;
            Vector3 look = transform.forward;
            float angle = Vector3.Angle(dir, look);

            RaycastHit hit;
            Ray ray = new Ray(transform.position, dir);

            if (angle < 30
                && (AllowedCharacterIdx == -1 || character != GameManager.Instance.Player.Characters[AllowedCharacterIdx])
                && Physics.Raycast(ray, out hit)
                && hit.transform.gameObject == character.gameObject)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
