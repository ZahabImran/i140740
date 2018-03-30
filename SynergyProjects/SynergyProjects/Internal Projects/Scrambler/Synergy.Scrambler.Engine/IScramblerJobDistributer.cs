using Synergy.Scrambler.Model.Configuration;

namespace Synergy.Scrambler.Engine
{
   public interface IScramblerJobDistributer
    {
       bool ValidateConfig(ProjectConfig PC);
        ProjectConfig GetScrambledConfig(ProjectConfig PC);
        ProjectConfig GetMaskingConfig(ProjectConfig PC);
        ProjectConfig GetHashConfig(ProjectConfig PC);
        ProjectConfig GetReplaceConfig(ProjectConfig PC);
        ProjectConfig GetParagraphConfig(ProjectConfig PC);



    }
}
