using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // skrypt odpowiadający za ruch gracza

    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private Rigidbody2D rb2d;                      // ridigbody, fizyczność
    [SerializeField] private Animator animation;
    [Header("Movement Variables")]
    [SerializeField] private float runSpeed = 40f;                  // szybkość ruchu gracza
    [SerializeField] private float movementSmoothing = .05f;        // płynność ruchu gracza

    float horizontalMove;                                           // ruch poziomy
    float verticalMove;                                             // ruch pionowy (skok)
    private Vector3 velocity;                                       // wektor ruchu
    bool playerJump = false;                                        // czy gracz jest w trakcie skoku
    bool isGrounded = true;                                        // czy gracz "stoi na ziemi"


    private void OnCollisionEnter2D(Collision2D col)                // co się dzieje gdy gracz wejdzie w kolizję z jakimś obiektem
    {
        animation.SetBool("isGrounded", true);
        isGrounded = true;          // ustawiamy, że gracz "stoi na ziemi"
        playerJump = false;         // ustawiamy, że gracz nie jest w trakcie skoku
    }

    private void OnCollisionExit2D(Collision2D col)                 // co się dzieje gry gracz opuści kolizję z jakimś obiektem
    {
        animation.SetBool("isGrounded", false);
        isGrounded = false;         // ustawiamy, że gracz "nie stoi na ziemi"
        playerJump = true;          // ustawiamy, że gracz jest w trakcie skoku
    }


    private void Move(float move)                                   // funkcja od poruszania się po osi lewo-prawo
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerSR.flipX = false;
            bulletPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerSR.flipX = true;
            bulletPoint.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        Vector3 targetVelocity = new Vector2(move * 10f, rb2d.velocity.y);                                      // właściwy ruch gracza
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, movementSmoothing);     // "wygładzanie" ruchu
    }

    private void Jump()                                                     // funkcja od skoku
    {
        if (Input.GetKeyDown(KeyCode.X))                                    // jeśli naciśniemy X (klawisz skoku)
        {              
            if (isGrounded)                                                 // i jeśli gracz stoi na ziemi
            {
                playerJump = true;                                          // ustawiamy że gracz jest w trakcie skoku
                rb2d.AddForce(new Vector2(0, Time.deltaTime * 58500));      // właściwy skok gracza
            }
        }
    }

    void Update()
    {
        // ustawiamy wartości zmiennych ruchu poziomego i pionowego
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;         
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // odpalamy funkcje od poruszania się i skoku
        Move(horizontalMove * Time.fixedDeltaTime);
        animation.SetFloat("runSpeed", (horizontalMove*Time.fixedDeltaTime));
        Jump();
    }
}
