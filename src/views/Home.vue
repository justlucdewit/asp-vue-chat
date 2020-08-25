<template>
  <div class="home">
    <Feed/>
    <TypingBar v-on:onMessage="newMessage" />
  </div>
</template>

<script>
import TypingBar from "@/components/TypingBar.vue";
import Feed from "@/components/Feed.vue";

export default {
  name: "Home",

  methods: {
    newMessage: function(message){
      console.log("adding new message")
      this.$store.commit('addMessage', {message: message, author: "luc"});

      // scroll to bottom of feed
      setTimeout(() => document.getElementById("feed").scrollTop = document.getElementById("feed").scrollHeight, 200);
      
    }
  },

  components: {
    TypingBar,
    Feed
  }

};
</script>
