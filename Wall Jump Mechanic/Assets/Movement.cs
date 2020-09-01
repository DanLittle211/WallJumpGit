using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public int jumpCount;
    public Rigidbody2D rb2D;
    public int thrust;
    public bool onJumpableSurface;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {  rb2D = GetComponent<Rigidbody2D>();  jumpCount = 1;  onJumpableSurface = true;  winText.gameObject.SetActive(false); }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpCount);
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Jump();  }
        if (Input.GetKeyUp(KeyCode.UpArrow)) { Gravity();}
        if (Input.GetKey(KeyCode.RightArrow)) { GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);  Gravity(); }
        if (Input.GetKey(KeyCode.LeftArrow)) { GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0); Gravity(); }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") { onJumpableSurface = true; jumpCount = 1; }
        if (other.gameObject.tag == "Goal") { winText.gameObject.SetActive(true); }
        if (other.gameObject.tag == "Death") { SceneManager.LoadScene("WallJumpScene"); }
    }
    private void Jump() { rb2D.AddForce(transform.up * thrust); jumpCount = 0; }
    private void Gravity() { rb2D.AddForce(-transform.up * 9); }
}
