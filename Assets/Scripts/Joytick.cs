<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Joytick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	public Image BGimage, joytickImage;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		BGimage = GetComponent<Image> ();

		joytickImage = transform.GetChild (0).GetComponentInChildren<Image> ();
		direction = Vector3.zero;
	}

	public void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
			BGimage.rectTransform, ped.position,
			ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / BGimage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / BGimage.rectTransform.sizeDelta.y);

			float x = (BGimage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (BGimage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			direction = new Vector3(x, 0, y);
			direction = (direction.magnitude > 1) ? direction.normalized : direction;

			joytickImage.rectTransform.anchoredPosition =
				new Vector2(direction.x * (BGimage.rectTransform.sizeDelta.x / 3),
					direction.z * (BGimage.rectTransform.sizeDelta.y / 3));
			
			Debug.Log(direction);
		}
	}

	public void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}

	public void OnPointerUp(PointerEventData ped)
	{
		direction = Vector3.zero;
		joytickImage.rectTransform.anchoredPosition = Vector3.zero;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Joytick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    private Image jsContainer;
    private Image joystick;

    public Vector3 InputDirection;
    // Use this for initialization
    void Start () {
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
    }

	public void OnDrag(PointerEventData ped)
	{
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, y, 0);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
                                                               , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);

    }

    public void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}

	public void OnPointerUp(PointerEventData ped)
	{
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
>>>>>>> 8a6a354fb94d05d089f96b76106fc510ed0806e5
