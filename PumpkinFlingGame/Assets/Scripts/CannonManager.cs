using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CannonManager : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public Text text;
    public GameObject bubble;
    

    public Slider forceUI;
    private Camera _cam;
    private bool _pressingMouse = false;
    private float power = 11;
    //private Vector2 launchSpeed;
    private float powerGauge;
    private float TempPos = 1.5f;
    private float TempPos2 = -0.35f;
    private bool upOrDown = true;
    private Vector3 mousePos;
    private Vector2 launchVelocity;
    //private Vector2 launchDirection;
    public int Distance = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI PreviousShot;
    public bool fired = false;
    private GameObject cannonBall;
    public HighScoreTable hs;
    public GameObject boom;


    // Start is called before the first frame update
    void Start()
    {
        //boom = 
        hs = new HighScoreTable();
        //HighScoreTable highScoreTable = gameObject.AddComponent<HighScoreTable>();
        //hs = highScoreTable;

        //hs = GetComponent<HighScoreTable>();
        // hs = gameObject.GetComponent<HighScoreTable>();
        // Debug.Log("THIS IS THE HS DEBUG LINE " + (hs == null));
        // hs.AddHighScoreEntry(100000, "TOM");

        _cam = Camera.main;
        power = forceUI.minValue;
        Distance = 0;
        scoreText.text = "Distance: " + Distance + " m";
        PreviousShot.text = "Previous Shot: " + MainManager.previousDistance + "m";

        // if (!TryGetComponent(out hs))
        // {
        //     Debug.LogError("HighScoreTable component not found on CannonManager game object!");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Power: " + power);
        // Debug.Log("Mouse: " + mousePos.magnitude);

        //Check whether the left mouse button or finger touch is pressed.
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            _pressingMouse = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            MainManager.setScore = false;
            MainManager.ballStopped = false;
            _pressingMouse = false;
            _Fire();
            fired = true;
        }

        if (_pressingMouse)
        {
            mousePos = Input.mousePosition;
            mousePos = _cam.ScreenToWorldPoint(mousePos);
            if (mousePos.x <= 1.5f)
            {
                mousePos = new Vector3(TempPos, mousePos.y, mousePos.z);
            }
            if (mousePos.y <= -0.35f)
            {
                mousePos = new Vector3(mousePos.x, TempPos2, mousePos.z);
            }
            Vector2 direction = new Vector2(mousePos.x, mousePos.y);
            transform.up = direction;

            //Calculate the launch direction based on the cannon's orientation
            Vector2 launchDirection = transform.up;

            //Captures the power gauge's intensity 
            powerGauge = applyValueOnSlider();

            //Calculate the launch velocity based on the launch direction and power gauge (multiplying by 2, this number makes the impluse stronger)
            launchVelocity = launchDirection.normalized * powerGauge * 5;
            Debug.Log(launchVelocity);

            //Debug.Log("Mouse Position" + mousePos.y);
        }


        if (fired)
        {
            if (cannonBall == null) return;
            Distance = (int)cannonBall.gameObject.transform.localPosition.x - (int)firePoint.transform.localPosition.x + 8;
            Distance = Mathf.Max(Distance, 0);
            //Debug.Log((int)cannonBall.gameObject.transform.localPosition.x);
            scoreText.text = "Distance: " + Distance + " m";
            MainManager.distance = Distance;
          //  bt.enabled = false;
            text.enabled = false;
            bubble.SetActive(false);
            boom.SetActive(true);
            boom.transform.position = firePoint.position;
        }
    }

    private void _Fire()
    {
        if (fired) return;

        // Debug.Log("Here1");
        if (_cam.transform.position.x <= -1.8f)
        {
            cannonBall = Instantiate(cannonBallPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb2d = cannonBall.GetComponent<Rigidbody2D>();
            rb2d.AddForce(launchVelocity, ForceMode2D.Impulse);
            fired = true;
        }

    }


    public float applyValueOnSlider()
    {
        if (upOrDown)
        {
            power += 0.05f;
            if (power >= forceUI.maxValue)
            {
                upOrDown = false;
            }
        }
        else if (!upOrDown)
        {
            power -= 0.05f;
            if (power <= forceUI.minValue)
            {
                upOrDown = true;
            }
        }
        return forceUI.value = power;
    }

    public void SetFired()
    {
        fired = false;
    }

    public void SetScore()
    {
        MainManager.previousDistance = Distance;
        PreviousShot.text = "Previous Shot: " + MainManager.previousDistance + "m";
        scoreText.text = "Distance: 0 M";
        //hs.AddHighScoreEntry(Distance, "TOM");
        //MainManager.distance = Distance;
        if (MainManager.chooseTom)
        {
        hs.AddHighScoreEntry(MainManager.distance, "TOM");

        }
        if (MainManager.chooseAmy)
        {
            hs.AddHighScoreEntry(MainManager.distance, "AMY");

        }
        //  Debug.Log(Distance);
    }
}