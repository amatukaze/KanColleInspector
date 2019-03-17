﻿using System;

namespace Sakuno.ING.Game.Models.MasterData
{
    public partial class ShipTypeInfo
    {
        public TextTranslationGroup Name { get; } = new TextTranslationGroup();

        partial void CreateCore()
        {
            Name.Origin = owner.Localization?.GetUnlocalized("ShipTypeName", Id.ToString());
            Name.Translation = owner.Localization?.GetLocalized("ShipTypeName", Id.ToString());
        }

        partial void UpdateCore(RawShipTypeInfo raw, DateTimeOffset timeStamp)
        {
            if (Name.Origin == null)
            {
                Name.Origin = raw.Name;
                NotifyPropertyChanged(nameof(Name));
            }
            availableEquipmentTypes.Query = owner.EquipmentTypes[raw.AvailableEquipmentTypes];
        }

        public override string ToString() => $"ShipTypeInfo {Id}: {Name.Origin}";
    }
}