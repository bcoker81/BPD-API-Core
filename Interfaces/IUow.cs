using BPD01_WebApi_Core.Domain;

namespace BPD01_WebApi_Core.Interfaces
{
    public interface IUow
    {
        IGenericRepo<AttachmentModel> AttachmentRepository {get;}
         IGenericRepo<GrantModel> GrantRepository {get;}
         IGenericRepo<CategoryModel> CategoryRepository {get;}
         IGenericRepo<CommentModel> CommentRepository {get;}
         IGenericRepo<DocumentModel> DocumentRepository {get;}
         IGenericRepo<ExpenditureModel> ExpenditureRepository {get;}
         IGenericRepo<GANModel> GANRepository {get;}
         IGenericRepo<LdprModel> LdprRepository {get;}
         IGenericRepo<PickListModel> PickListRepository {get;}
         IGenericRepo<ReportDateModel> ReportRepository {get;}
         void Save();
    }
}