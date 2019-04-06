﻿using System.Linq;
using Sakuno.ING.Composition;
using Sakuno.ING.Game;
using Sakuno.ING.Game.Models;
using Sakuno.ING.Game.Models.Combat;
using Sakuno.ING.Game.Models.MasterData;
using Sakuno.ING.Localization;
using Sakuno.ING.Settings;

namespace Sakuno.ING.Views.UWP
{
    public static class Helpers
    {
        public static bool IsNotNull(object obj) => obj != null;
        public static bool Not(bool value) => !value;

        private static readonly bool translate
            = Compositor.Static<LocaleSetting>().TranslateContent.InitialValue;
        public static string SelectName(TextTranslationGroup name)
            => translate ? name.Translation : name.Origin;
        public static string SelectShipName(ShipName name)
            => SelectName(name);

        public static string Localize(string category, object value, string format)
            => localization.GetLocalized(category, string.Format(format, value));

        private static readonly ILocalizationService localization;
        static Helpers()
        {
            localization = Compositor.Static<ILocalizationService>();
            admiralRankTexts = Enumerable.Range(1, 10)
                .Select(i => localization.GetLocalized("GameModel", "AdmiralRank_" + i))
                .ToArray();
            fireRangeTexts = Enumerable.Range(0, 5)
                .Select(i => localization.GetLocalized("GameModel", "FireRange_" + i))
                .ToArray();
            shipSpeedTexts = Enumerable.Range(0, 5)
                .Select(i => localization.GetLocalized("GameModel", "ShipSpeed_" + i * 5))
                .ToArray();
            dockEmpty = localization.GetLocalized("GameModel", "Dock_Empty");
            dockLocked = localization.GetLocalized("GameModel", "Dock_Locked");

            phaseShelling = localization.GetLocalized("Combat", "ShellingPhase");
            phaseOpeningAsw = localization.GetLocalized("Combat", "OpeningAswPhase");
            phaseOpeningTorpedo = localization.GetLocalized("Combat", "TorpedoPhase_Opening");
            phaseClosingTorpedo = localization.GetLocalized("Combat", "TorpedoPhase_Closing");
            phaseAerial = localization.GetLocalized("Combat", "AerialPhase");
            phaseAerial2 = localization.GetLocalized("Combat", "AerialPhase_2");
            phaseJet = localization.GetLocalized("Combat", "AerialPhase_Jet");
            phaseLandBaseJet = localization.GetLocalized("Combat", "AerialPhase_Jet_LandBase");
            phaseLandBase = localization.GetLocalized("Combat", "LandBasePhase");
            phaseSupport = localization.GetLocalized("Combat", "SupportPhase");
            phaseNight = localization.GetLocalized("Combat", "NightPhase");
            phaseNightCombined = localization.GetLocalized("Combat", "NightPhase_Combined");
            phaseNpc = localization.GetLocalized("Combat", "NpcPhase");

            mapEventKindTexts = Enumerable.Range(0, 10)
                .Select(i => localization.GetLocalized("Combat", "MapEventKind_" + i))
                .ToArray();
            battleKindTexts = Enumerable.Range(1, 8)
                .Select(i => localization.GetLocalized("Combat", "BattleKind_" + i))
                .ToArray();
        }

        private static readonly string[] admiralRankTexts;
        public static string FormatAdmiralRank(AdmiralRank rank) => rank switch
        {
            AdmiralRank.MarshalAdmiral => admiralRankTexts[0],
            AdmiralRank.Admiral => admiralRankTexts[1],
            AdmiralRank.ViceAdmiral => admiralRankTexts[2],
            AdmiralRank.RearAdmiral => admiralRankTexts[3],
            AdmiralRank.Captain => admiralRankTexts[4],
            AdmiralRank.Commander => admiralRankTexts[5],
            AdmiralRank.NoviceCommander => admiralRankTexts[6],
            AdmiralRank.LieutenantCommander => admiralRankTexts[7],
            AdmiralRank.ViceLieutenantCommander => admiralRankTexts[8],
            AdmiralRank.NoviceLieutenantCommander => admiralRankTexts[9],
            _ => null
        };

        private static readonly string[] fireRangeTexts;
        public static string FormatFireRange(FireRange range) => range switch
        {
            FireRange.None => fireRangeTexts[0],
            FireRange.Short => fireRangeTexts[1],
            FireRange.Medium => fireRangeTexts[2],
            FireRange.Long => fireRangeTexts[3],
            FireRange.VeryLong => fireRangeTexts[4],
            _ => null
        };

        private static readonly string[] shipSpeedTexts;
        public static string FormatShipSpeed(ShipSpeed speed) => speed switch
        {
            ShipSpeed.None => shipSpeedTexts[0],
            ShipSpeed.Slow => shipSpeedTexts[1],
            ShipSpeed.Fast => shipSpeedTexts[2],
            ShipSpeed.FastPlus => shipSpeedTexts[3],
            ShipSpeed.UltraFast => shipSpeedTexts[4],
            _ => null
        };

        private static readonly string dockEmpty, dockLocked;
        public static string FormatBuildingDockState(BuildingDockState state) => state switch
        {
            BuildingDockState.Empty => dockEmpty,
            BuildingDockState.Locked => dockLocked,
            _ => null
        };
        public static string FormatRepairingDockState(RepairingDockState state) => state switch
        {
            RepairingDockState.Empty => dockEmpty,
            RepairingDockState.Locked => dockLocked,
            _ => null
        };

        public static bool FleetStateEquals(FleetState left, FleetState right)
            => left == right;

        private static readonly string
            phaseShelling,
            phaseOpeningAsw,
            phaseOpeningTorpedo,
            phaseClosingTorpedo,
            phaseAerial,
            phaseAerial2,
            phaseJet,
            phaseLandBaseJet,
            phaseLandBase,
            phaseSupport,
            phaseNight,
            phaseNightCombined,
            phaseNpc;
        public static string FormatBattlePhaseTitle(BattlePhase phase) => phase switch
        {
            OpeningAswPhase _ => phaseOpeningAsw,
            ShellingPhase shelling => string.Format(phaseShelling, shelling.Index),
            TorpedoPhase torpedo => torpedo.IsOpening ? phaseOpeningTorpedo : phaseClosingTorpedo,
            JetPhase jet => jet.IsLandBase ? phaseLandBaseJet : phaseJet,
            LandBasePhase landBase => string.Format(phaseLandBase, landBase.Index),
            AerialPhase aerial => aerial.Index == 2 ? phaseAerial2 : phaseAerial,
            SupportPhase _ => phaseSupport,
            NpcPhase _ => phaseNpc,
            CombinedNightPhase combined => string.Format(phaseNightCombined, combined.Index),
            NightPhase _ => phaseNight,
            _ => null
        };

        private static readonly string[] mapEventKindTexts;
        public static string FormatMapEvent(MapEventKind kind)
        {
            int id = (int)kind;
            if (id >= 0 && id < 10) return mapEventKindTexts[id];
            else return null;
        }

        private static readonly string[] battleKindTexts;
        public static string FormatBattleKind(BattleKind kind)
        {
            int id = (int)kind - 1;
            if (id >= 0 && id < 8) return battleKindTexts[id];
            else return null;
        }
    }
}