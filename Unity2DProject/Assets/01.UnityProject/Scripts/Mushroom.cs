using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("¡¢√À");
        if (collision.tag.Equals("Player"))
        {
            if (GameManager.instance.isMushroom == false)
            {
                GameManager.instance.isMushroom = true;
                collision.gameObject.transform.localScale *= 2f;
            }
            else { gameObject.SetActive(false); }
        }
    }
}
