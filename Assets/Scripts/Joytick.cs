using System.Collections;
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
