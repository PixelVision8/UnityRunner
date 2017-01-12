﻿//  
// Copyright (c) Jesse Freeman. All rights reserved.  
// 
// Licensed under the Microsoft Public License (MS-PL) License. 
// See LICENSE file in the project root for full license information. 
// 
// Contributors
// --------------------------------------------------------
// This is the official list of Pixel Vision 8 contributors:
//  
// Jesse Freeman - @JesseFreeman
// Christer Kaitila - @McFunkypants
// Pedro Medeiros - @saint11
// 

using PixelVisionSDK.Engine.Chips.IO.Controller;
using UnityEngine;

/// <summary>
///     This class helps capture keyboard input and needs to be registered with the ControllerChip.
/// </summary>
/// <example>
///     controllerChip.UpdateControllerKey(0, new KeyboardButtonInput(Button.A, 120);
/// </example>
public class KeyboardButtonInput : ButtonState
{

    protected int keyCode;

    public KeyboardButtonInput(Buttons button, int keyCode)
    {
        this.button = button;
        mapping = keyCode;
        this.keyCode = keyCode;
    }

    public override void Update(float timeDelta)
    {
        value = Input.GetKey((KeyCode) keyCode);
        base.Update(timeDelta);
    }

}