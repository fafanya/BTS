﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTS.Client.TrackingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TStorage", Namespace="http://schemas.datacontract.org/2004/07/Kernel.Service")]
    [System.SerializableAttribute()]
    public partial class TStorage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Dictionary<string, object> FieldsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PKFieldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TableField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Dictionary<string, object> Fields {
            get {
                return this.FieldsField;
            }
            set {
                if ((object.ReferenceEquals(this.FieldsField, value) != true)) {
                    this.FieldsField = value;
                    this.RaisePropertyChanged("Fields");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PKField {
            get {
                return this.PKFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.PKFieldField, value) != true)) {
                    this.PKFieldField = value;
                    this.RaisePropertyChanged("PKField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Table {
            get {
                return this.TableField;
            }
            set {
                if ((object.ReferenceEquals(this.TableField, value) != true)) {
                    this.TableField = value;
                    this.RaisePropertyChanged("Table");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TrackingService.ITrackingService")]
    public interface ITrackingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Insert", ReplyAction="http://tempuri.org/ITrackingService/InsertResponse")]
        int Insert(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Insert", ReplyAction="http://tempuri.org/ITrackingService/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Update", ReplyAction="http://tempuri.org/ITrackingService/UpdateResponse")]
        void Update(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Update", ReplyAction="http://tempuri.org/ITrackingService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Delete", ReplyAction="http://tempuri.org/ITrackingService/DeleteResponse")]
        void Delete(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/Delete", ReplyAction="http://tempuri.org/ITrackingService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(BTS.Client.TrackingService.TStorage storage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/LoadList", ReplyAction="http://tempuri.org/ITrackingService/LoadListResponse")]
        BTS.Client.TrackingService.TStorage[] LoadList(BTS.Client.TrackingService.TStorage query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/LoadList", ReplyAction="http://tempuri.org/ITrackingService/LoadListResponse")]
        System.Threading.Tasks.Task<BTS.Client.TrackingService.TStorage[]> LoadListAsync(BTS.Client.TrackingService.TStorage query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/LoadDetails", ReplyAction="http://tempuri.org/ITrackingService/LoadDetailsResponse")]
        BTS.Client.TrackingService.TStorage LoadDetails(BTS.Client.TrackingService.TStorage query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITrackingService/LoadDetails", ReplyAction="http://tempuri.org/ITrackingService/LoadDetailsResponse")]
        System.Threading.Tasks.Task<BTS.Client.TrackingService.TStorage> LoadDetailsAsync(BTS.Client.TrackingService.TStorage query);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITrackingServiceChannel : BTS.Client.TrackingService.ITrackingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TrackingServiceClient : System.ServiceModel.ClientBase<BTS.Client.TrackingService.ITrackingService>, BTS.Client.TrackingService.ITrackingService {
        
        public TrackingServiceClient() {
        }
        
        public TrackingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TrackingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrackingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TrackingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Insert(BTS.Client.TrackingService.TStorage storage) {
            return base.Channel.Insert(storage);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(BTS.Client.TrackingService.TStorage storage) {
            return base.Channel.InsertAsync(storage);
        }
        
        public void Update(BTS.Client.TrackingService.TStorage storage) {
            base.Channel.Update(storage);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(BTS.Client.TrackingService.TStorage storage) {
            return base.Channel.UpdateAsync(storage);
        }
        
        public void Delete(BTS.Client.TrackingService.TStorage storage) {
            base.Channel.Delete(storage);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(BTS.Client.TrackingService.TStorage storage) {
            return base.Channel.DeleteAsync(storage);
        }
        
        public BTS.Client.TrackingService.TStorage[] LoadList(BTS.Client.TrackingService.TStorage query) {
            return base.Channel.LoadList(query);
        }
        
        public System.Threading.Tasks.Task<BTS.Client.TrackingService.TStorage[]> LoadListAsync(BTS.Client.TrackingService.TStorage query) {
            return base.Channel.LoadListAsync(query);
        }
        
        public BTS.Client.TrackingService.TStorage LoadDetails(BTS.Client.TrackingService.TStorage query) {
            return base.Channel.LoadDetails(query);
        }
        
        public System.Threading.Tasks.Task<BTS.Client.TrackingService.TStorage> LoadDetailsAsync(BTS.Client.TrackingService.TStorage query) {
            return base.Channel.LoadDetailsAsync(query);
        }
    }
}
