import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    messages: []
  },

  mutations: {
    addMessage: function(state, message){
      state.messages.push(message);
    }
  },

  getters: {
    allMessages: state => state.messages
  },

  actions: {},
  modules: {}
});
