using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    Transform canvas, blockHolder, player;
    Button[] buttons = new Button[7];
    public float interactionDistance = 3f;
    int picked = 0;
    public Transform[] blocks = new Transform[7];
    float timer = 0;

    void Start()
    {
        Find();
        // SetListeners();
        StartTimer();
    }

    void Update(){
        ClickButtons();
        BuildAndDestroy();
    }

    void ClickButtons(){
        for(int i = 49; i < 56; i++){
            if(Input.GetKeyDown((KeyCode)i)){
                Clicked(i - 49);
            }
        }
    }

    void StartTimer(){
        timer = 0;
    }

    void BuildAndDestroy(){
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            if (Physics.Raycast(player.GetChild(0).position, player.GetChild(0).forward, out hit, interactionDistance))
            {
                if(hit.transform.gameObject.GetComponent<BlockBehaviour>() != null){
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        if(Input.GetButtonDown("Fire2")){
            RaycastHit hit;
            
            if (Physics.Raycast(player.GetChild(0).position, player.GetChild(0).forward, out hit, interactionDistance))
            {
                Transform blockIns = Instantiate(blocks[picked], blockHolder);
                blockIns.position = hit.transform.position + hit.normal;
            }
        }
    }

    void Find(){
        canvas = GameObject.Find("Canvas").transform;
        blockHolder = GameObject.Find("Blocks").transform;
        player = GameObject.Find("FPSController").transform;
        for(int i = 0; i < 7; i++){
            buttons[i] = canvas.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetComponent<Button>();
        }
    }

    // void SetListeners(){
    //     for(int i = 0; i < 7; i++){
    //         int locali = i;
    //         buttons[locali].onClick.AddListener(() => Clicked(locali));
    //     }
    // }

    void Clicked(int i){
        picked = i;

        for(int j = 0; j < 7; j++){
            buttons[j].GetComponent<Image>().color = new Color(1,1,1,0.4f);
        }
        
        buttons[picked].GetComponent<Image>().color = new Color(1,0,0,0.4f);
    }
}
