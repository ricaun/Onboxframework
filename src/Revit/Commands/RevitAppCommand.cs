﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Onbox.Abstractions.VDev;
using Onbox.Revit.VDev.Applications;

namespace Onbox.Revit.VDev.Commands
{
    /// <summary>
    /// Base class to implement Revit Commands linked to a App Container
    /// <br>It will use a scope of the container declared on the App</br>
    /// </summary>
    public abstract class RevitAppCommand<TApplication> : IExternalCommand, IRevitDestroyableCommand where TApplication : RevitApp, new()
    {
        /// <summary>
        /// Execution of External Command
        /// </summary>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Gets the original container
            IContainer container = GetContainer();

            // Creates an scoped copy of the container
            var scope = container.CreateScope();

            try
            {
                // Runs the users Execute command
                return Execute(scope, commandData, ref message, elements);
            }
            catch
            {
                // If an exception is thrown on user's code, trows it back to the stack
                throw;
            }
            finally
            {
                // Safely calls lifecycle hook 
                try
                {
                    this.OnDestroy(scope);
                }
                catch
                {
                }

                // Cleans up the scoped copy of the container
                scope.Dispose();
            }
        }

        private static IContainer GetContainer()
        {
            var type = typeof(TApplication);
            var containerGuid = ContainerProviderReflector.GetContainerGuid(type);
            var container = RevitContainerProviderBase.GetContainer(containerGuid);
            return container;
        }

        /// <summary>
        /// Execution of External Command
        /// </summary>
        public abstract Result Execute(IContainerResolver container, ExternalCommandData commandData, ref string message, ElementSet elements);

        /// <summary>
        /// External Command lifecycle hook which is called just before the scoped container is disposed.
        /// </summary>
        public virtual void OnDestroy(IContainerResolver container)
        {
        }
    }
}