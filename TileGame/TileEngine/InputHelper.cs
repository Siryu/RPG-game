﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TileEngine
{
    public static class InputHelper
    {
        static KeyboardState newState;
        static KeyboardState oldState;

        public static void Update()
        {
            oldState = newState;
            newState = Keyboard.GetState();
        }

        public static bool IsNewPress(Keys key)
        {
            return (newState.IsKeyDown(key) && oldState.IsKeyUp(key));
        }

        public static bool IsKeyDown(Keys key)
        {
            return newState.IsKeyDown(key);
        }
    }
}
