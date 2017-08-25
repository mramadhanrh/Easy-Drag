using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrag : MonoBehaviour {

    public int value;

    bool isDragging;

    GameObject g;
    Vector3 z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDragging)
        {
            z = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));            
            z.z = 0;
            g.transform.position = z;
        }
	}

    void OnMouseDown()
    {
        isDragging = true;
        g = new GameObject("go");
        g.transform.localScale = transform.localScale;
        g.AddComponent<SpriteRenderer>();
        g.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        g.GetComponent<SpriteRenderer>().color = new Color(g.GetComponent<SpriteRenderer>().color.r, g.GetComponent<SpriteRenderer>().color.g, g.GetComponent<SpriteRenderer>().color.b, 0.5f);
        Constans.clickedValue = value;
        Debug.Log(Constans.clickedValue);
    }

    void OnMouseUp()
    {
        Constans.clickedValue = 0f;
        Destroy(g.gameObject);
        isDragging = false;
    }
}
