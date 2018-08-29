﻿// Copyright 2018 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

namespace GooglePlayInstant.Samples.TestApp
{
    /// <summary>
    /// Tests instant app plugin features through button clicks
    /// </summary>
    public class TestApp : MonoBehaviour
    {
        private const string CookiePrefix = "test-cookie";
        private string _storedCookie;

        /// <summary>
        /// Sets the instant app cookie to a unique string
        /// </summary>
        public void BtnEvt_WriteCookie()
        {
            //Write a random value so WriteCookie will always change the cookie
            var guid = Random.Range(int.MinValue, int.MaxValue);
            _storedCookie = string.Format("{0}:{1}", guid, CookiePrefix);
            CookieApi.SetInstantAppCookie(_storedCookie);
            Debug.LogFormat("Wrote a cookie: {0}", _storedCookie);
        }
        
        /// <summary>
        /// Reads the cookie and verifies if it matches the one we stored
        /// </summary>
        public void BtnEvt_ReadCookie()
        {
            // TODO: Currently reading the cookie from the instant app. Prefer to read it from installed app.
            var readCookie = CookieApi.GetInstantAppCookie();
            Debug.LogFormat("Read a cookie: {0}", readCookie);
            if (string.Equals(readCookie, _storedCookie))
            {
                Debug.LogFormat("{0} matches the value we stored", _storedCookie);
            }
            else
            {
                Debug.LogFormat("{0} does not match the value we stored: {1}", readCookie, _storedCookie);
            }
        }
        
        public void BtnEvt_ShowInstallPrompt()
        {
            // TODO: test all aspects of this API
            InstallLauncher.ShowInstallPrompt();
        }
    }
}