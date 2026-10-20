


using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    public Vector2 InputDirection { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (joystickBackground == null ||
            joystickHandle == null)
            return;

        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            Vector2 halfSize =
                joystickBackground.rect.size / 2f;

            InputDirection = new Vector2(
                localPoint.x / halfSize.x,
                localPoint.y / halfSize.y
            );

            InputDirection =
                Vector2.ClampMagnitude(InputDirection, 1f);

            joystickHandle.anchoredPosition =
                new Vector2(
                    InputDirection.x * halfSize.x * 0.5f,
                    InputDirection.y * halfSize.y * 0.5f
                );
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;

        if (joystickHandle != null)
        {
            joystickHandle.anchoredPosition = Vector2.zero;
        }
    }
}
