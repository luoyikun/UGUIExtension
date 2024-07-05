using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DynamicGridClickHelper : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// Graphic
    /// </summary>
    Graphic m_Graphic = null;

    /// <summary>
    /// 回调事件
    /// </summary>
    public Action<PointerEventData> OnClick;
    public Action<int, int, DynamicGrid> DynamicTableGridDelegate;
    public DynamicGrid m_grid;
    public delegate void OnTableGridTouched(DynamicGrid grid, PointerEventData eventData);
    public OnTableGridTouched m_OnTableGridTouched;
    /// <summary>
    /// 点击
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //if (OnClick != null)
        //    OnClick(eventData);
        if (m_OnTableGridTouched != null)
        {
            m_OnTableGridTouched(m_grid, eventData);
        }
    }

    public void SetupClickEnable(bool IsEnable, Action<PointerEventData> onClick = null)
    {
        m_Graphic = GetComponent<Graphic>();
        if (m_Graphic == null)
            m_Graphic = gameObject.AddComponent<Empty4Raycast>();

        m_Graphic.raycastTarget = IsEnable;
        OnClick = onClick;
    }

}
