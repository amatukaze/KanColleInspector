﻿using DynamicData;
using DynamicData.Aggregation;
using ReactiveUI;
using Sakuno.ING.Game.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace Sakuno.ING.ViewModels.Homeport
{
    public sealed class FleetViewModel : ReactiveObject, IHomeportTabViewModel
    {
        public PlayerFleet Model { get; }

        public IReadOnlyCollection<ShipViewModel> Ships { get; }

        private readonly ObservableAsPropertyHelper<int> _totalLevel;
        public int TotalLevel => _totalLevel.Value;

        private readonly ObservableAsPropertyHelper<int> _speed;
        public ShipSpeed Speed => (ShipSpeed)_speed.Value;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => this.RaiseAndSetIfChanged(ref _isSelected, value);
        }

        public FleetViewModel(PlayerFleet fleet)
        {
            Model = fleet;

            var ships = fleet.Ships.AsObservableChangeSet();
            Ships = ships.Transform(r => new ShipViewModel(r)).Bind();

            _totalLevel = ships.Sum(r => r.Leveling.Level).ObserveOn(RxApp.MainThreadScheduler).ToProperty(this, nameof(TotalLevel), deferSubscription: true);
            _speed = ships.Minimum(r => (int)r.Speed).ObserveOn(RxApp.MainThreadScheduler).ToProperty(this, nameof(ShipSpeed));
        }
    }
}
