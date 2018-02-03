using DeathValley.BLL.DTO;

namespace DeathValley.BLL.Interfaces
{
    public interface IParamService
    {
        int GetIdIfExist(ParamDTO paramDto);
        //void Add(ParamDTO paramDto);
        void Dispose();
    }
}