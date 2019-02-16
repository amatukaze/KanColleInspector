﻿using System;

namespace Sakuno.ING.Game.Models
{
    public partial class RepairingDock
    {
        private HomeportShip _repairingShip;
        public HomeportShip RepairingShip
        {
            get => _repairingShip;
            internal set
            {
                if (_repairingShip != value)
                {
                    _repairingShip?.SetRepaired();
                    if (value != null)
                        value.IsRepairing = true;
                    _repairingShip = value;
                    NotifyPropertyChanged();
                }
            }
        }

        partial void UpdateCore(RawRepairingDock raw, DateTimeOffset timeStamp)
        {
            RepairingShip = owner.AllShips[raw.RepairingShipId];
            UpdateTimer(timeStamp);
        }

        internal void Instant()
        {
            State = RepairingDockState.Empty;
            RepairingShip = null;
            CompletionTime = null;
            TimeRemaining = null;
        }

        internal void UpdateTimer(DateTimeOffset timeStamp)
        {
            if (RepairingShip == null || CompletionTime == null)
                TimeRemaining = null;
            else if (timeStamp > CompletionTime)
                TimeRemaining = default(TimeSpan);
            else
                TimeRemaining = CompletionTime - timeStamp;
        }
    }
}