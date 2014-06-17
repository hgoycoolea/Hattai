﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.hattai.listener.presenter.HattaiPaymentSandboxEndpoint {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://2get.mobi/", ConfigurationName="HattaiPaymentSandboxEndpoint.IHattaiPaymentSandbox")]
    public interface IHattaiPaymentSandbox {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://2get.mobi/IHattaiPaymentSandbox/CommitToAdyenSandbox", ReplyAction="http://2get.mobi/IHattaiPaymentSandbox/CommitToAdyenSandboxResponse")]
        System.Collections.Generic.List<string> CommitToAdyenSandbox(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://2get.mobi/IHattaiPaymentSandbox/CommitToAdyenSandbox", ReplyAction="http://2get.mobi/IHattaiPaymentSandbox/CommitToAdyenSandboxResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> CommitToAdyenSandboxAsync(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHattaiPaymentSandboxChannel : com.hattai.listener.presenter.HattaiPaymentSandboxEndpoint.IHattaiPaymentSandbox, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HattaiPaymentSandboxClient : System.ServiceModel.ClientBase<com.hattai.listener.presenter.HattaiPaymentSandboxEndpoint.IHattaiPaymentSandbox>, com.hattai.listener.presenter.HattaiPaymentSandboxEndpoint.IHattaiPaymentSandbox {
        
        public HattaiPaymentSandboxClient() {
        }
        
        public HattaiPaymentSandboxClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HattaiPaymentSandboxClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HattaiPaymentSandboxClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HattaiPaymentSandboxClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<string> CommitToAdyenSandbox(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client) {
            return base.Channel.CommitToAdyenSandbox(Currency, Amount, Cvc, ExpMonth, ExpYear, CardHolderName, CardNumber, ShopperEmail, Reference, ip, SignatureImage, UID, Longitude, Latitude, Client);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> CommitToAdyenSandboxAsync(string Currency, string Amount, string Cvc, string ExpMonth, string ExpYear, string CardHolderName, string CardNumber, string ShopperEmail, string Reference, string ip, string SignatureImage, string UID, string Longitude, string Latitude, int Client) {
            return base.Channel.CommitToAdyenSandboxAsync(Currency, Amount, Cvc, ExpMonth, ExpYear, CardHolderName, CardNumber, ShopperEmail, Reference, ip, SignatureImage, UID, Longitude, Latitude, Client);
        }
    }
}