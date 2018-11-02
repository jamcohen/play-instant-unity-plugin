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

using System;
using UnityEngine;
using UnityEngine.Networking;

namespace GooglePlayInstant.SplitInstall
{
    /// <summary>
    /// Provides methods to obtain an AssetBundle
    /// </summary>
    public class WebRequestProvider : IAssetBundleProvider
    {
        private readonly string _assetBundleUrl;
        private UnityWebRequest _webRequest; // TODO: Provide a method to dispose this request.

        public WebRequestProvider(string assetBundleUrl)
        {
            _assetBundleUrl = assetBundleUrl;
        }

        public IProgressiveTask StartDownload()
        {
            if (_webRequest != null)
            {
                _webRequest.Dispose();
                _webRequest = null;
            }

#if UNITY_2018_1_OR_NEWER
            _webRequest = UnityWebRequestAssetBundle.GetAssetBundle(_assetBundleUrl);
#else
            _webRequest = UnityWebRequest.GetAssetBundle(_assetBundleUrl);
#endif

            var downloadOperation = GooglePlayInstantUtils.SendWebRequest(_webRequest);
            return new WebRequestTask(downloadOperation);
        }

        public bool IsError()
        {
            return GooglePlayInstantUtils.IsNetworkError(_webRequest);
        }

        public string GetError()
        {
            return _webRequest.error;
        }

        public AssetBundle GetAssetBundle()
        {
            return DownloadHandlerAssetBundle.GetContent(_webRequest);
        }
    }

    public class WebRequestTask : IProgressiveTask
    {
        private readonly AsyncOperation _downloadOperation;

        public WebRequestTask(AsyncOperation downloadOperation)
        {
            _downloadOperation = downloadOperation;
        }

        public float GetProgress()
        {
            return _downloadOperation.progress;
        }

        public bool IsDone()
        {
            return _downloadOperation.isDone;
        }
    }
}