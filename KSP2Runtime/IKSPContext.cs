﻿using System;
using System.Collections.Generic;
using KontrolSystem.TO2.Runtime;
using KontrolSystem.KSP.Runtime.KSPConsole;
using KontrolSystem.KSP.Runtime.KSPOrbit;
using KSP.Game;
using KSP.Sim.impl;

namespace KontrolSystem.KSP.Runtime {
    public interface IMarker {
        bool Visible { get; set; }
        void Update();
        void OnRender();
    }

    public interface IFixedUpdateObserver {
        void OnFixedUpdate(double deltaTime);
    }

    public interface IKSPContext : IContext {
        GameState CurrentGameState { get; }

        KSPConsoleBuffer ConsoleBuffer { get; }

        KSPOrbitModule.IBody FindBody(string name);
        
        object NextYield { get; set; }

        void AddMarker(IMarker marker);

        void RemoveMarker(IMarker marker);

        void ClearMarkers();

        void AddFixedUpdateObserver(IFixedUpdateObserver observer);

        void HookAutopilot(VesselComponent vessel, FlightInputCallback autopilot);

        void UnhookAutopilot(VesselComponent vessel, FlightInputCallback autopilot);

        void UnhookAllAutopilots(VesselComponent vessel);
    }

    public class KSPContext {
        public static IKSPContext CurrentContext {
            get {
                IKSPContext context = ContextHolder.CurrentContext.Value as IKSPContext;
                if (context == null) throw new ArgumentException($"No current IKSPContext");
                return context;
            }
        }
    }
}
