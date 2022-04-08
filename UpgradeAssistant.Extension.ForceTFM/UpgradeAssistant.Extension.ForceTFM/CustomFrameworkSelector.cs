using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.DotNet.UpgradeAssistant;
using Microsoft.Extensions.Options;

namespace UpgradeAssistant.Extension.ForceTFM
{
    public class CustomTargetFrameworkSelector : ITargetFrameworkSelector
    {
        private readonly ITargetFrameworkMonikerComparer _comparer;
        private readonly TfmOption _tfmOption;
        private readonly TfmOptionMap _tfmOptionMap;

        public CustomTargetFrameworkSelector(ITargetFrameworkMonikerComparer comparer,
            IOptions<TfmOption> tfmOptions,
            IOptions<TfmOptionMap> tfmOptionMap)
        {
            _comparer = comparer;
            _tfmOption = tfmOptions?.Value ?? throw new ArgumentNullException(nameof(tfmOptions));
            _tfmOptionMap = tfmOptionMap.Value ?? throw new ArgumentNullException(nameof(tfmOptionMap));;
        }

        public ValueTask<TargetFrameworkMoniker> SelectTargetFrameworkAsync(IProject project, CancellationToken token)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            var appBase = _tfmOption.Tfm switch
            {
                "Current" => _tfmOptionMap.Current,
                "Preview" => _tfmOptionMap.Preview,
                "LTS" => _tfmOptionMap.LTS,
                _ => _tfmOptionMap.LTS,
            };

            if (!_comparer.TryParse(appBase, out var appBaseTfm))
            {
                throw new InvalidOperationException("Invalid app base TFM");
            }

            return new ValueTask<TargetFrameworkMoniker>(appBaseTfm);
        }
    }
}