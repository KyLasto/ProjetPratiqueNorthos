using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
   public string message;

   private void OnMouseEnter()
   {
      ToolTipManager.m_Instance.SetAndShowToolTip(message);
   }

   private void OnMouseExit()
   {
      ToolTipManager.m_Instance.HideToolTip();
   }
}
