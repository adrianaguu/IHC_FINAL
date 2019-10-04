using UnityEngine;
using System.Collections;

public class mira : MonoBehaviour {
	public float sizeX;
	public float sizeY;
	public float MaxsizeBetwen;
	public float MinsizeBetwen;
	public float speed;
	private float intervalo;
	public Texture2D textura;
	private CharacterController controller;
	
	void OnGUI()
	{
		if (controller.isGrounded)
		{
			if (controller.velocity.magnitude > 0.1 & intervalo < MaxsizeBetwen)
			{
				intervalo += speed;
			}
			else if (intervalo > MinsizeBetwen)
			{
				intervalo -= speed;
			}
		}
		else if (intervalo < MaxsizeBetwen)
		{
				intervalo += speed*1.5f;
		}
		
		float posx = Screen.width/2.4f;
		float posy = Screen.height/2.4f;
		GUI.DrawTexture (new Rect (posx - (sizeX/2) -intervalo, posy - (sizeY/2), sizeX, sizeY), textura);
		GUI.DrawTexture (new Rect (posx - (sizeX/2) +intervalo, posy - (sizeY/2), sizeX, sizeY), textura);
		GUI.DrawTexture (new Rect (posx - (sizeY/2), posy - sizeX/2+intervalo, sizeY, sizeX), textura);
		GUI.DrawTexture (new Rect (posx - (sizeY/2), posy - sizeX/2-intervalo, sizeY, sizeX), textura);		
	}
	
	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
		intervalo = MinsizeBetwen;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
