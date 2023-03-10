using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    [SerializeField] private float delayTime;
    [SerializeField] private Vector2 exitDirection;
    private float timePassed;
    private bool countDown = false;

    private void Update()
    {
        CheckRefresh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            timePassed = 0;
            countDown = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            if((exitDirection.x< 0 && direction.x < 0) ||(exitDirection.x > 0 && direction.x > 0)
                || (exitDirection.y < 0 && direction.z < 0) || (exitDirection.y > 0 && direction.z > 0))
            {
                countDown = true;
            }
        }
    }

    void CheckRefresh()
    {
        if(countDown)
        {
            timePassed += Time.deltaTime;
            if(timePassed >= delayTime)
            {
                SceneManager.UnloadSceneAsync(sceneNumber);
                SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);
            }
        }
    }
}