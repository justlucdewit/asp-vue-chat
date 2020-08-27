<template>
  <div id="feed">
    <span v-for="message of messages" v-bind:key="message">
      <b
        v-bind:style="`color:hsl(${message.color}, 100%, 50%)`"
        class="messageHeader"
      >
        <span class="nameTag">{{ message.author }}</span>
        <h6>{{ buildDate(new Date(message.date)) }}</h6>
      </b>
      <div class="messageContent">{{ message.message }}</div>
      <hr />
    </span>
  </div>
</template>

<script>
export default {
  methods: {
    buildDate: function(date) {
      return `${
        date.toDateString() == new Date().toDateString()
          ? "today"
          : new Intl.DateTimeFormat("en", {
              year: "numeric",
              month: "short",
              day: "2-digit"
            }).format(date)
      } ${date.getHours() < 10 ? "0" + date.getHours() : date.getHours()}:${
        date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes()
      }`;
    }
  },

  computed: {
    messages() {
      return this.$store.getters.allMessages;
    }
  }
};
</script>

<style lang="scss">
#feed {
  width: 70vw;
  height: 70vh;
  display: inline;
  border: 1px solid #000;
  margin-bottom: 20px;
  float: left;
  margin-left: 15vw;
  text-align: left;
  padding-left: 20px;
  padding-top: 10px;
  overflow: scroll;
}

.nameTag {
  font-weight: 900;
}

.messageContent {
  margin-bottom: 20px;
}

.messageHeader h6 {
  display: inline;
  margin-left: 20px;
  color: gray;
}
</style>
