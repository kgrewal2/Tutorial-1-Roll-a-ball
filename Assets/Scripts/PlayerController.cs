using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float speed;
   private Rigidbody rb;
   private int score;
   public Text countText;
   public Text winText;
   void Start(){
      score =0;
      rb = GetComponent<Rigidbody>();
      setScoreText();
      winText.text = "";
   }
   void FixedUpdate(){
         float moveHorizontal = Input.GetAxis("Horizontal");
         float moveVertical = Input.GetAxis("Vertical");
         Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
         rb.AddForce(movement*speed);
   }
   void OnTriggerEnter(Collider other) {
      if(other.gameObject.CompareTag("Pickup")){
         other.gameObject.SetActive(false);
         score = score + 1;
         setScoreText();
      }
   }
   void setScoreText(){
      countText.text = "Count: "+score.ToString();
      if(score>=6){
         winText.text = "You Win";
      }
   }

}
