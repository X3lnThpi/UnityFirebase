using UnityEngine;
using UnityEngine.UI;

public class TicTac : MonoBehaviour
{
    public Button playButton;
    public Canvas canvas;
    public bool cellStatus;
    State cellState;
    public enum State
    {
        empty,
        X,
        O
    }
    public enum Turn
    {
        player1,
        player2
    }

    public SpriteRenderer grid;
    float x = -1.5f;
    float y = -2f;
    void DisableCanvas()
    {
        canvas.enabled = false;
    }

    void Start()
    {
        
        
        float tempY = y;
        float tempX = x;
        playButton.onClick.AddListener(DisableCanvas);
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Instantiate(grid, new Vector3(x, y, 0), Quaternion.identity);
                x += 1.7f;
                grid.gameObject.name = i + " " + j;
                cellState = State.empty;
            }
            y = tempY;
            y += 1.7f;
            tempY = y;
            x = tempX;
        }
    }

    private void Update()
    {
        int nTouches = Input.touchCount;

        if (nTouches > 0)
        {
            Debug.Log(nTouches + "Touch Detected");

            for (int i = 0; i < nTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                //Debug.Log("Touch Index " + touch.fingerId + "detected at " + touch.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 100f);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Cell")
                    {
                        Debug.Log("hit Cell");
                        
                    }
                }
            }
        }
    }
}
