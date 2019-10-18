﻿using UnityEngine;

namespace Library.Events
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Events/Void Event")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}
