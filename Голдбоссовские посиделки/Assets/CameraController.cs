using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.SceneManagement;public class CameraController : MonoBehaviour{    private Transform player;    private Hero hero;    private Vector3 position;    private void Awake()    {        if (!player)        {            player = FindObjectOfType<Hero>().transform;        }    }
    // Start is called before the first frame update
    void Start()    {        player = FindObjectOfType<Hero>().transform;
        //if (hero.Lives <= 0)
        {            SceneManager.LoadScene(1);        }    }

    // Update is called once per frame
    void Update()    {        if (player)        {            position = player.position;            position.z = -10f;            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);        }

    }}
