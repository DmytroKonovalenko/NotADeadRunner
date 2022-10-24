using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    private CapsuleCollider col;
    public InterAd interAd;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private int coins;
    [SerializeField] private Text coinsText;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameObject scoreText;
    private int lineToMove = 1;
    private int tryCount;
    public float lineDistanse = 4;
    private float maxSpeed =110;
    private bool Roll;
    private bool isImmortal;
    private Animator anim;
    private Score score;
    // Start is called before the first frame update
    void Start()
    {
        
        score = scoreText.GetComponent<Score>();
        col = GetComponent<CapsuleCollider>();
        controller = GetComponent<CharacterController>();
        StartCoroutine(SpeedIncrease());
        score.scoreMultiplier = 1;
        Time.timeScale = 1;
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        anim = GetComponentInChildren<Animator>();
        isImmortal = false;



        tryCount = PlayerPrefs.GetInt("tryCount");
    }
    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("Jump");
    }
    private void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    private void Update()
    {
        if(SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }
        if (SwipeController.swipeLeft)
        {
            anim.SetTrigger("Left");
            if (lineToMove > 0)
                lineToMove--;
        }
        if (SwipeController.swipeUp)
        {
            if(controller.isGrounded)
               Jump();
        }
        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (controller.isGrounded && !Roll)
            anim.SetBool("Running", true);
        else
            anim.SetBool("Running", false);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistanse;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistanse;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
        
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="obstacle")
        {
            if (isImmortal)
                Destroy(hit.gameObject);
            else
            {
                tryCount++;
                PlayerPrefs.SetInt("tryCount",tryCount);
                if (tryCount % 2 == 0)
                    interAd.ShowAd();
                losePanel.SetActive(true);
                int lastRunScore = int.Parse(scoreScript.scoreText.text.ToString());
                PlayerPrefs.SetInt("lastRunScore", lastRunScore);
                Time.timeScale = 0;
            }
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BonusStar")
        {
            StartCoroutine(StarBonus());
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Shiels")
        {
            StartCoroutine(Shield());
            Destroy(other.gameObject);
        }

    }
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(1   );
        if(speed<maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
        
    }
    private IEnumerator Slide()
    {
        col.center = new Vector3(0, 0.5343708f, 0);
        col.height = 1.486586f;
        Roll = true;
        anim.SetTrigger("Roll");

        yield return new WaitForSeconds(1);

        col.center = new Vector3(0, 1.201419f, 0);
        col.height = 2.820683f;
        Roll = false;
    }
    private IEnumerator StarBonus()
    {
        score.scoreMultiplier = 2;
        yield return new WaitForSeconds(5);
        score.scoreMultiplier = 1;
    }
    private IEnumerator Shield()
    {
        isImmortal = true;
        yield return new WaitForSeconds(5);
        isImmortal = false;
    }

}
