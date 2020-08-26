import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const generateGuestNumber = () => {
  const baseNr = Math.floor(Math.random() * 10000);
  return (
    baseNr < 10 ? '000' + baseNr :
    baseNr < 100 ? '00' + baseNr :
    baseNr < 1000 ? '0' + baseNr :
    baseNr);
};

export default new Vuex.Store({
  state: {
    messages: [],
    account: {
      name: "guest" + generateGuestNumber(),
      color: Math.floor(Math.random() * 360),
      server: "global"
    }
  },

  mutations: {
    addMessage: function(state, message){
      state.messages.push(message);
    },

    setMessages: function(state, messages){
      state.messages = messages;
    },

    setName: function(state, name){
      state.account.name = name;
    },

    setColor: function(state, value){
      state.account.color = Math.floor(value % 360);
    },

    setChannel: function(state, name){
      state.account.server = name;
    }
  },

  getters: {
    allMessages: state => state.messages,
    name: state => state.account.name,
    color: state => state.account.color,
    server: state => state.account.server
  },

  actions: {},
  modules: {}
});
