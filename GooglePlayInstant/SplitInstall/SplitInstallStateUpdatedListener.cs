﻿// <copyright file="PlayServicesResolver.cs" company="Google Inc.">
// Copyright (C) 2015 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>

using System;
using UnityEngine;

namespace GooglePlayInstant.SplitInstall
{
    public class SplitInstallStateUpdatedListener : AndroidJavaProxy
    {
        public event Action<SplitInstallSessionState> OnStateUpdateEvent = delegate { };

        public SplitInstallStateUpdatedListener() : base(
            "com.google.android.play.core.splitinstall.SplitInstallStateUpdatedListener")
        {
        }

        // Proxied java calls. Method names are camelCase to match the corresponding java methods.

        public void onStateUpdate(AndroidJavaObject splitInstallSessionState)
        {
            OnStateUpdateEvent.Invoke(new SplitInstallSessionState(splitInstallSessionState));
        }

        public int hashCode()
        {
            return GetHashCode();
        }

        public string toString()
        {
            return "SplitInstallStateUpdatedListener";
        }
    }
}