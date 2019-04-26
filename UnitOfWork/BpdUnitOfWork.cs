using System;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Entities;
using BPD01_WebApi_Core.Interfaces;
using BPD01_WebApi_Core.Repository;

namespace BPD01_WebApi_Core.UnitOfWork
{
    public class BpdUnitOfWork : IUow, IDisposable
    {
        private readonly BpdDbContext _context;

        private IGenericRepo<AttachmentModel> _attachmentRepository;
        private IGenericRepo<GrantModel> _grantRepostory;
        private IGenericRepo<CategoryModel> _categoryRepostory;
        private IGenericRepo<CommentModel> _commentRepostory;
        private IGenericRepo<DocumentModel> _documentRepostory;
        private IGenericRepo<ExpenditureModel> _expenditureRepostory;
        private  IGenericRepo<GANModel> _gANRepostory;
        private  IGenericRepo<LdprModel> _ldprRepostory;
        private IGenericRepo<PickListModel> _pickListRepostory;
        private IGenericRepo<ReportDateModel> _reportRepostory;

        public BpdUnitOfWork(BpdDbContext context)
        {
            _context = context;
        }

        public IGenericRepo<GrantModel> GrantRepository{
            get{return _grantRepostory ?? (_grantRepostory = new GenericRepository<GrantModel>(_context));}
        }

        public IGenericRepo<CategoryModel> CategoryRepository{
            get{return _categoryRepostory ?? (_categoryRepostory = new GenericRepository<CategoryModel>(_context));}
        }

        public IGenericRepo<CommentModel> CommentRepository{
            get{return _commentRepostory ?? (_commentRepostory = new GenericRepository<CommentModel>(_context));}
        }

        public IGenericRepo<DocumentModel> DocumentRepository{
            get{return _documentRepostory ?? (_documentRepostory = new GenericRepository<DocumentModel>(_context));}
        }

        public IGenericRepo<ExpenditureModel> ExpenditureRepository{
            get{return _expenditureRepostory ?? (_expenditureRepostory = new GenericRepository<ExpenditureModel>(_context));}
        }

        public IGenericRepo<GANModel> GANRepository{
            get{return _gANRepostory ?? (_gANRepostory = new GenericRepository<GANModel>(_context));}
        }

        public IGenericRepo<LdprModel> LdprRepository{
            get{return _ldprRepostory ?? (_ldprRepostory = new GenericRepository<LdprModel>(_context));}
        }

        public IGenericRepo<PickListModel> PickListRepository{
            get{return _pickListRepostory ?? (_pickListRepostory = new GenericRepository<PickListModel>(_context));}
        }

        public IGenericRepo<ReportDateModel> ReportRepository{
            get{return _reportRepostory ?? (_reportRepostory = new GenericRepository<ReportDateModel>(_context));}
        }

          public IGenericRepo<AttachmentModel> AttachmentRepository{
            get{return _attachmentRepository ?? (_attachmentRepository = new GenericRepository<AttachmentModel>(_context));}
        }

        public void Save(){
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing){
            if(!this.disposed){if(disposing){_context.Dispose();}}
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}