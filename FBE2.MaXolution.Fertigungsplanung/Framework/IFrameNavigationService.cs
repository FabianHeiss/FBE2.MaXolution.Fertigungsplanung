using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBE2.MaXolution.Fertigungsplanung.Framework
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
