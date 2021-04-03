﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISpawn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    TileValues tVal;
    GameObject temp;
    StateManager state;

    public TileValues.TileType tileType;

    int num;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        tVal = GameObject.Find("GameManager").GetComponent<TileValues>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.wetlands)
        {
            //Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
           // Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;
            rot.z -= 1;
            temp = Instantiate(tVal.GetWet(), pos, rot);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.bioswale)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;
            rot.z -= 1;
            temp = Instantiate(tVal.GetBio(), pos, rot);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.house)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;
            rot.z -= 1;
            temp = Instantiate(tVal.GetHouse(), pos, rot);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.road)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(pos);
            pos.x += 5.2f;
            pos.y -= 2.8f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;
            rot.z -= 1;
            temp = Instantiate(tVal.GetRoad(), pos, rot);
        }

        temp.name = temp.name + num;
        state.SetSpawn(false);

        TileValues tileValues = GameObject.Find("GameManager").GetComponent<TileValues>();
        tileValues.AssignValues(num, tileType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(true);
    }
}
