// Copyright 2018 Google LLC
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

using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace GooglePlayInstant.SplitInstall
{
    /// <summary>
    /// Provides methods to obtain an AssetBundle
    /// </summary>
    public class SplitInstallProvider : IAssetBundleProvider
    {
        private readonly string _splitName;
        private readonly SplitInstallManager _splitInstallManager;
        
        public SplitInstallProvider(string splitName)
        {
            _splitName = splitName;
            _splitInstallManager = new SplitInstallManager();
        }
        
        public AsyncOperation StartDownload()
        {
            _splitInstallManager.StartModuleInstall(_splitName);
        }

        public bool IsError()
        {
            return true;
        }

        public string GetError()
        {
            return "Not yet implemented";
        }

        public AssetBundle GetAssetBundle()
        {
            return null;
        }
    }
}