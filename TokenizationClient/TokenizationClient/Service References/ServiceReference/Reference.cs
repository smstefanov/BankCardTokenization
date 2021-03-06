﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokenizationClient.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IToken")]
    public interface IToken {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/ValidationAndLuhnCheck", ReplyAction="http://tempuri.org/IToken/ValidationAndLuhnCheckResponse")]
        bool ValidationAndLuhnCheck(string cardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/ValidationAndLuhnCheck", ReplyAction="http://tempuri.org/IToken/ValidationAndLuhnCheckResponse")]
        System.Threading.Tasks.Task<bool> ValidationAndLuhnCheckAsync(string cardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/CreateToken", ReplyAction="http://tempuri.org/IToken/CreateTokenResponse")]
        string CreateToken(string cardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/CreateToken", ReplyAction="http://tempuri.org/IToken/CreateTokenResponse")]
        System.Threading.Tasks.Task<string> CreateTokenAsync(string cardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsRegistered", ReplyAction="http://tempuri.org/IToken/IsRegisteredResponse")]
        bool IsRegistered(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsRegistered", ReplyAction="http://tempuri.org/IToken/IsRegisteredResponse")]
        System.Threading.Tasks.Task<bool> IsRegisteredAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsValidLog", ReplyAction="http://tempuri.org/IToken/IsValidLogResponse")]
        bool IsValidLog(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsValidLog", ReplyAction="http://tempuri.org/IToken/IsValidLogResponse")]
        System.Threading.Tasks.Task<bool> IsValidLogAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/LoadCardID", ReplyAction="http://tempuri.org/IToken/LoadCardIDResponse")]
        string LoadCardID(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/LoadCardID", ReplyAction="http://tempuri.org/IToken/LoadCardIDResponse")]
        System.Threading.Tasks.Task<string> LoadCardIDAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/XMLUserSave", ReplyAction="http://tempuri.org/IToken/XMLUserSaveResponse")]
        void XMLUserSave(string user, string pass, int access);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/XMLUserSave", ReplyAction="http://tempuri.org/IToken/XMLUserSaveResponse")]
        System.Threading.Tasks.Task XMLUserSaveAsync(string user, string pass, int access);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/XMLTokenSave", ReplyAction="http://tempuri.org/IToken/XMLTokenSaveResponse")]
        void XMLTokenSave(string tokenID, string CardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/XMLTokenSave", ReplyAction="http://tempuri.org/IToken/XMLTokenSaveResponse")]
        System.Threading.Tasks.Task XMLTokenSaveAsync(string tokenID, string CardID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsTokenInSystem", ReplyAction="http://tempuri.org/IToken/IsTokenInSystemResponse")]
        bool IsTokenInSystem(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/IsTokenInSystem", ReplyAction="http://tempuri.org/IToken/IsTokenInSystemResponse")]
        System.Threading.Tasks.Task<bool> IsTokenInSystemAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/SortByToken", ReplyAction="http://tempuri.org/IToken/SortByTokenResponse")]
        void SortByToken();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/SortByToken", ReplyAction="http://tempuri.org/IToken/SortByTokenResponse")]
        System.Threading.Tasks.Task SortByTokenAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/SortByCardID", ReplyAction="http://tempuri.org/IToken/SortByCardIDResponse")]
        void SortByCardID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToken/SortByCardID", ReplyAction="http://tempuri.org/IToken/SortByCardIDResponse")]
        System.Threading.Tasks.Task SortByCardIDAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITokenChannel : TokenizationClient.ServiceReference.IToken, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TokenClient : System.ServiceModel.ClientBase<TokenizationClient.ServiceReference.IToken>, TokenizationClient.ServiceReference.IToken {
        
        public TokenClient() {
        }
        
        public TokenClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TokenClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TokenClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidationAndLuhnCheck(string cardID) {
            return base.Channel.ValidationAndLuhnCheck(cardID);
        }
        
        public System.Threading.Tasks.Task<bool> ValidationAndLuhnCheckAsync(string cardID) {
            return base.Channel.ValidationAndLuhnCheckAsync(cardID);
        }
        
        public string CreateToken(string cardID) {
            return base.Channel.CreateToken(cardID);
        }
        
        public System.Threading.Tasks.Task<string> CreateTokenAsync(string cardID) {
            return base.Channel.CreateTokenAsync(cardID);
        }
        
        public bool IsRegistered(string username) {
            return base.Channel.IsRegistered(username);
        }
        
        public System.Threading.Tasks.Task<bool> IsRegisteredAsync(string username) {
            return base.Channel.IsRegisteredAsync(username);
        }
        
        public bool IsValidLog(string username, string password) {
            return base.Channel.IsValidLog(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsValidLogAsync(string username, string password) {
            return base.Channel.IsValidLogAsync(username, password);
        }
        
        public string LoadCardID(string token) {
            return base.Channel.LoadCardID(token);
        }
        
        public System.Threading.Tasks.Task<string> LoadCardIDAsync(string token) {
            return base.Channel.LoadCardIDAsync(token);
        }
        
        public void XMLUserSave(string user, string pass, int access) {
            base.Channel.XMLUserSave(user, pass, access);
        }
        
        public System.Threading.Tasks.Task XMLUserSaveAsync(string user, string pass, int access) {
            return base.Channel.XMLUserSaveAsync(user, pass, access);
        }
        
        public void XMLTokenSave(string tokenID, string CardID) {
            base.Channel.XMLTokenSave(tokenID, CardID);
        }
        
        public System.Threading.Tasks.Task XMLTokenSaveAsync(string tokenID, string CardID) {
            return base.Channel.XMLTokenSaveAsync(tokenID, CardID);
        }
        
        public bool IsTokenInSystem(string token) {
            return base.Channel.IsTokenInSystem(token);
        }
        
        public System.Threading.Tasks.Task<bool> IsTokenInSystemAsync(string token) {
            return base.Channel.IsTokenInSystemAsync(token);
        }
        
        public void SortByToken() {
            base.Channel.SortByToken();
        }
        
        public System.Threading.Tasks.Task SortByTokenAsync() {
            return base.Channel.SortByTokenAsync();
        }
        
        public void SortByCardID() {
            base.Channel.SortByCardID();
        }
        
        public System.Threading.Tasks.Task SortByCardIDAsync() {
            return base.Channel.SortByCardIDAsync();
        }
    }
}
