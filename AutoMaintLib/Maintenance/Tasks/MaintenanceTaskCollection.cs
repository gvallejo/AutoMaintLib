using AutoMaintLib.Cars.Model;
using AutoMaintLib.Maintenance.Guides;
using AutoMaintLib.Maintenance.Tasks.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Maintenance.Tasks
{
    public class MaintenanceTaskCollection : IList<MaintenanceTask>
    {
        private IMaintenanceTaskValidator m_MaintenanceTaskValidator = null;
        private List<MaintenanceTask> m_list = null;

        public MaintenanceTaskCollection()            
        {
            this.m_list = new List<MaintenanceTask>();                  
        }


        public MaintenanceTaskCollection(IMaintenanceTaskValidator maintenanceTaskValidator)
            : this()
        {
            SetValidator(maintenanceTaskValidator);
        }

        private void SetValidator(IMaintenanceTaskValidator maintenanceTaskValidator)
        {
            this.m_MaintenanceTaskValidator = maintenanceTaskValidator;
        }

        public int IndexOf(MaintenanceTask item)
        {
            return this.m_list.IndexOf(item);
        }       

        public void Insert(int index, MaintenanceTask item)
        {
            ValidateMaintenanceTask(item);
            this.m_list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.m_list.RemoveAt(index);
        }

        public MaintenanceTask this[int index]
        {
            get
            {
                return this.m_list[index];
            }
            set
            {
                this.m_list[index] = value;
            }
        }

        public void Add(MaintenanceTask item)
        {
            ValidateMaintenanceTask(item);                                
           this.m_list.Add(item);           
        }

        public void Sort()
        {
            this.m_list.Sort();
        }

        public MaintenanceTask FindByTaskType(TaskEnum taskType)
        {
            return this.m_list.SingleOrDefault<MaintenanceTask>(MaintenanceTask.ByTaskType(taskType));
        }
        
        public bool Contains(MaintenanceTask item)
        {
            return this.m_list.Contains(item);
        }

        public void CopyTo(MaintenanceTask[] array, int arrayIndex)
        {
            this.m_list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.m_list.Count; }
        }

        public bool IsReadOnly
        {
            get { return (this.m_list as ICollection<MaintenanceTask>).IsReadOnly; }
        }

        public bool Remove(MaintenanceTask item)
        {
            return this.m_list.Remove(item);
        }

        public bool Remove(TaskEnum taskType)
        {
            MaintenanceTask item = FindByTaskType(taskType);
            bool result = false;
            
            if(item != null)
                result = this.m_list.Remove(item);

            return result;
        }

        public IEnumerator<MaintenanceTask> GetEnumerator()
        {
            return (this.m_list as IEnumerable<MaintenanceTask>).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (this.m_list as IEnumerable).GetEnumerator();
        }


        public void Clear()
        {
            this.m_list.Clear();
        }

        public void Validate()
        {
            foreach (MaintenanceTask task in this.m_list)
            {
                ValidateMaintenanceTask(task);
            }
        }



        private void ValidateMaintenanceTask(MaintenanceTask item)
        {
            IEnumerable<string> errors = null;

            if (!item.IsValid(this.m_MaintenanceTaskValidator, out errors))
                throw new InvalidOperationException(errors.ElementAt<string>(0));
        }
    }
}
