﻿using System;

namespace Onbox.Revit.V7
{
    /// <summary>
    /// Revit Application version, name, language and window handle
    /// </summary>
    public class RevitAppData : IRevitAppData
    {
        internal RevitLanguage languageType;
        internal string subVersionNumber;
        internal string versionNumber;
        internal string versionBuild;
        internal string versionName;
        internal IntPtr revitWindowHandle;
        internal bool isViewerMode;

        /// <summary>
        /// Revit's language
        /// </summary>
        public RevitLanguage GetLanguage()
        {
            return languageType;
        }

        /// <summary>
        /// Revit's sub version number
        /// </summary>
        public string GetSubVersionNumber()
        {
            return subVersionNumber;
        }

        /// <summary>
        /// Revit's build version
        /// </summary>
        public string GetVersionBuild()
        {
            return versionBuild;
        }

        /// <summary>
        /// Revit's build version name
        /// </summary>
        public string GetVersionName()
        {
            return versionName;
        }

        /// <summary>
        /// Revit's version number
        /// </summary>
        public string GetVersionNumber()
        {
            return versionNumber;
        }

        /// <summary>
        /// Revit's window handler pointer
        /// </summary>
        public IntPtr GetRevitWindowHandle()
        {
            return revitWindowHandle;
        }

        /// <summary>
        /// Flag to tell if revit was lanched in Viewer mode
        /// </summary>
        public bool GetIsViewerMode()
        {
            return isViewerMode;
        }
    }
}
